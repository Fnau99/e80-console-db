using System.Data;
using classReservations;

namespace testReservation
{
    [TestClass]
    public class UnitTestReservation
    {
        [TestMethod]
        public void TestCustomers()
        {
            //initialize the object reservation for call them constructors, methods and class
            Reservation reservation = new Reservation();

            //Variable that contain test and save in this the final table
            DataTable customers;
            customers = reservation.Customers();

            //controls
            if (customers == null)
            {
                throw new Exception("Customers load failed");
            }

            if (customers.Rows.Count != 930)
            {
                throw new Exception("Customers count doesn't match");
            }

        }

        [TestMethod]
        public void TestCustomers2()
        {
            //initialize the object reservation for call them constructors, methods and class
            Reservation reservation = new Reservation();

            //Variable that contain test and save in this the final table
            DataTable customers;
            customers = reservation.Customers("Claudio", "Rossi");

            //Controls if the count is right
            if(customers.Rows.Count != 5)
            {
                throw new Exception("The count of Paolo Rossi isn't right");
            }


        }


    }
}