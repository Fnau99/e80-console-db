using System.Data;
using System.Data.SqlClient;
using classReservations;

string FirstName = " ";
string SecondName = " ";
int id = 0;
DataTable dataTable;
DataSet dataSet;

//Declare object of type reservations
Reservation reservation;
reservation = new Reservation();

//Call methods reservations, no values
reservation.Reservations();

//Call methods reservations, 1 value
id = reservation.GetValueID("Inserisci l'id", id);
reservation.Reservations(id);

//Call methods reservations, 2 values
SecondName = reservation.GetValueSurName("Inserisci il cognome", SecondName);
FirstName = reservation.GetValueName("Inserisci il nome", FirstName);
reservation.Reservations(FirstName, SecondName);



