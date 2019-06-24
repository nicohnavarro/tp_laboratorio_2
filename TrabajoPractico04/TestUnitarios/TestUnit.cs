using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnit
    {
        [TestMethod]
        public void TestIntanceOfListPackage()
        {
            //ARRANGE
            Correo correoPrueba;
            //ACT
            correoPrueba = new Correo();
            //ASSERT
            Assert.IsNotNull(correoPrueba);
            Assert.IsNotNull(correoPrueba.Paquetes);
        }

        [TestMethod]
        [ExpectedException (typeof(TrackingIdRepetidoException))]
        public void TestSameTrackingID()
        {
            //ARRANGE
            Correo correoPrueba=new Correo();
            //Mismo TrackingID en ambos Paquetes
            Paquete paquetePrueba1 = new Paquete("Mitre 670", "01");
            Paquete paquetePrueba2 = new Paquete("Belgrano 560", "01");
            //ACT
            correoPrueba +=paquetePrueba1;
            correoPrueba += paquetePrueba2;
            //ASSERT Controlado por la excepcion
            
        }
    }

}
