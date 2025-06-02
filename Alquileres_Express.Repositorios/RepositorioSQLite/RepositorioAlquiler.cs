using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;

namespace Alquileres_Express.Repositorios.RepositorioSQLite;

public class RepositorioAlquiler : IRepositorioAlquiler
{
    readonly Alquileres_ExpressContext _context = new Alquileres_ExpressContext();
    public void RegistrarAlquilerPresencial(String correo, Inmueble inmueble, DateTime fechaInicio, DateTime fechaFin)
    {
        bool existe = _context.Clientes.Any(x => x.Correo.ToLower() == correo.ToLower());
        if (!existe)
            throw new InvalidOperationException("El correo no esta vinculado a ningun cliente.");
        double precio = calcularPrecio(fechaInicio, fechaFin, inmueble.Precio);
        //Crear alquiler
        //Guardar en base de datos
    }

    private double calcularPrecio(DateTime fechaInicio, DateTime fechaFin, double monto)
    {
        int cantidadDias = (fechaFin - fechaInicio).Days;
        double precioTotal = cantidadDias * monto;
        return precioTotal;

    }
}
