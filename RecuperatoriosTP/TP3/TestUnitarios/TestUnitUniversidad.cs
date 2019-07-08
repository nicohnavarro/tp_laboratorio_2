using System;
using Archivos;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitUniversidad
    {
        /// <summary>
        /// Test unitario que validen Excepciones
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestValidacionDeExcepcionesI()
        {
            //Arrange
            Alumno alumno1 = new Alumno(1, "Jorge", "Perez", "11203940", Persona.ENacionalidad.Extranjero,
                Universidad.EClases.Laboratorio);
            //Act
            //Asserge
            //Manejado por la Excepcion
        }

        /// <summary>
        /// Test unitario que validen Excepciones
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestValidacionDeExcepcionesII()
        {
            //Arrange
            Texto texto = new Texto();
            //Act
            texto.Guardar(string.Empty, "***********");
            //Assert
            //Manejado por la Excepcion
        }

        /// <summary>
        /// Test unitario que validen Excepciones
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestValidacionDeExcepcionesIII()
        {
            //Arrange
            Universidad uniprueba = new Universidad();
            Profesor profesorPrueba = new Profesor(2, "Jose", "Amelio", "11239032"
                , Persona.ENacionalidad.Argentino);
            //Act
            uniprueba += Universidad.EClases.SPD;
            profesorPrueba = uniprueba == Universidad.EClases.Programacion;
            //Assert
            //Manejado por la Excepcion
        }

        /// <summary>
        /// Test unitario que validen Excepciones
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestValidacionDeExcepcionesIV()
        {
            //Arrange
            Alumno alumno1 = new Alumno(1, "Pedro", "Perez", "12345678"
                , Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(1, "Pedro", "Perez", "12345678"
                , Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Universidad uniPrueba = new Universidad();
            //Act
            uniPrueba += alumno1;
            uniPrueba += alumno2;
            //Assert
            //Manejado por la Excepcion
        }

        [TestMethod]
        public void TestValidacionV()
        {
            //Arrange
            Alumno alumno1 = new Alumno(1, "Pedro", "Perez", "12345678"
                , Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(1, "Pedro", "Perez", "12345678"
                , Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Profesor profe1 = new Profesor(1, "Pedro", "Perez", "12345678", Persona.ENacionalidad.Argentino);
            //Act
            bool a = alumno1 == alumno2;
            bool b = alumno1 == profe1;

            //Assert
            Assert.AreEqual(true, a);
            Assert.AreNotEqual(true, b);
        }

        /// <summary>
        ///Generar al menos uno que valide un valor numérico?
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestValidacionDeExcepcionesVI()
        {
            //Arrange
            Alumno alumnopruba = new Alumno(1, "Nicolas", "Perez", "1234a6b8", 
                Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            //Act
            //Assert
            //Manejado por la Excepcion
        }

        /// <summary>
        ///Generar al menos uno que valide un valor numérico?
        /// </summary>
        [TestMethod]
        public void TestValidacionVII()
        {
            //Arrange
            int numero1 = 2;
            int numero2 = 3;
            int resutadoProbable;
            int resultadoEsperado = 6;
            //Act
            resutadoProbable = numero1 * numero2;
            //Assert
            Assert.AreEqual(resultadoEsperado, resutadoProbable);

        }
        /// <summary>
        /// Generar al menos uno que valide que no haya valores nulos 
        /// en algún atributo de las clases dadas.
        /// </summary>
        [TestMethod]
        public void TestValidacionVIII()
        {
            //Arrange
            Universidad universidad = new Universidad();
            //Act
            //Assert
            Assert.IsNotNull(universidad.Jornadas);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}
