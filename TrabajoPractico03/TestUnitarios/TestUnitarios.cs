using System;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestNull()
        {
            Profesor p = new Profesor(111, "Franco", "Armani", null, Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadException()
        {
            Alumno uno = new Alumno(222, "Juan Fernando", "Quintero", "3767464", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
        }

        [TestMethod]
        public void TestValorNumerico()
        {
            Alumno alumno = new Alumno(333, "Leonardo", "Ponzio", "37904306", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
        }
    }
}
