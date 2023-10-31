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

            if(customers == null)
            {
                throw new Exception("Customers load failed");
            }

            if (customers.Rows.Count != 930)
            {
                throw new Exception("Customers count doesn't match");
            }
            
        }
    }
}