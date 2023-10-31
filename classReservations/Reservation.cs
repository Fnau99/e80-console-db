using System.Data;
using System.Data.SqlClient;

namespace classReservations
{
	public class Reservation
	{
        #region Properties

        string connectionString;
        string queryString = " ";
        SqlConnection connection;
        SqlDataAdapter adapter;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor, uses localhost and integrated authentication
        /// </summary>
        public Reservation()
		{
			this.connectionString = "Data Source=(local);Initial Catalog=prenotazioni;Integrated Security=True";

			//Call method to do the connection
            this.ConnectToDB();
        }

		/// <summary>
		/// Default constructor, uses localhost and integrated authentication
		/// </summary>
		/// <param name="server">server name or address</param>
		/// <param name="database">database name</param>
		public Reservation(string server, string database)
		{
			this.connectionString = $"Data Source={server};" +
				$"Initial Catalog={database};" +
				$"Integrated Security=True";

            //Call method to do the connection
            this.ConnectToDB();
        }

		/// <summary>
		/// Default constructor, uses localhost and integrated authentication
		/// </summary>
		/// <param name="server">server name or address</param>
		/// <param name="database">database name</param>
		/// <param name="username">username</param>
		/// <param name="password">password</param>
		public Reservation(string server, string database, string username, string password)
		{
			this.connectionString = $"user id={username};" +
				$"data source='{server}';" +
				$"persist security info=True;" +
				$"initial catalog={database};" +
				$"password={password};" +
				$"MultipleActiveResultSets=true";

            //Call method to do the connection
            this.ConnectToDB();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads all customers data
        /// </summary>
        /// <returns></returns>
        
        //Query that return the table client
        public DataTable Customers()
		{
			DataTable result;
            SqlCommand command;
            DataSet dataSet;

            //loads from data table
            result = new DataTable();
            queryString = "SELECT * FROM clienti";

            command = new SqlCommand(queryString, this.connection);

            adapter = new SqlDataAdapter(queryString, this.connection);

            dataSet = new DataSet();
            adapter.Fill(dataSet, "Clienti");

            result = dataSet.Tables["Clienti"];

            //loads data from database
            return result;
		}

        public DataTable Customers(string nome, string cognome)
        {
            DataTable result;
            SqlCommand command;
            DataSet dataSet;

            result = new DataTable();
            queryString = "SELECT nome, cognome " +
                            "FROM clienti " +
                            $"WHERE nome LIKE '%{nome}%' AND cognome LIKE '%{cognome}%'";

            command = new SqlCommand(queryString, this.connection);

            adapter = new SqlDataAdapter(queryString, this.connection);

            dataSet = new DataSet();
            adapter.Fill(dataSet, "Clienti");

            result = dataSet.Tables["Clienti"];

            //loads data from database
            return result;
        }

        public DataTable Reservations()
        {
            DataTable result;
            SqlCommand command;
            DataSet dataSet;

            result = new DataTable();
            queryString =   "SELECT ID_prenotazione, arrivo, partenza, importo, tipo_struttura " +
                            "FROM clienti " +
                            "JOIN prenotazioni ON clienti.ID_cliente = prenotazioni.cliente ";
                            
            command = new SqlCommand(queryString, this.connection);

            adapter = new SqlDataAdapter(queryString, this.connection);

            dataSet = new DataSet();
            adapter.Fill(dataSet, "Clienti");

            result = dataSet.Tables["Clienti"];

            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"{row["ID_prenotazione"],-10} | {row["arrivo"],-10} | {row["partenza"],-10} | {row["importo"],-10} | {row["tipo_struttura"],-10}");
            }

            //loads data from database
            return result;
        }

        public DataTable Reservations(int Id)
        {
            DataTable result;
            SqlCommand command;
            DataSet dataSet;

            result = new DataTable();
            queryString =   "SELECT ID_prenotazione, arrivo, partenza, importo, tipo_struttura " +
                            "FROM prenotazioni " +
                            "JOIN clienti ON ID_cliente = cliente " + 
                            $"WHERE ID_cliente = '{Id}' ";

            command = new SqlCommand(queryString, this.connection);

            adapter = new SqlDataAdapter(queryString, this.connection);

            dataSet = new DataSet();
            adapter.Fill(dataSet, "Clienti");

           result = dataSet.Tables["Clienti"];

            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"{row["ID_prenotazione"],-10} | {row["arrivo"],-10} | {row["partenza"],-10} | {row["importo"],-10} | {row["tipo_struttura"],-10}");
            }

            //loads data from database
            return result;
        }

        public DataTable Reservations(string nome, string cognome)
        {
            DataTable result;
            SqlCommand command;
            DataSet dataSet;

            result = new DataTable();
            queryString =   "SELECT ID_prenotazione, arrivo, partenza, importo, tipo_struttura " +
                            "FROM clienti " +
                            "JOIN prenotazioni ON ID_cliente = cliente " +
                            $" WHERE nome = '{nome}' " +
                            $" AND cognome = '{cognome}' ";
            
            command = new SqlCommand(queryString, this.connection);

            adapter = new SqlDataAdapter(queryString, this.connection);

            dataSet = new DataSet();
            adapter.Fill(dataSet, "Clienti");

            result = dataSet.Tables["Clienti"];

            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"{row["ID_prenotazione"],-10} | {row["arrivo"],-10} | {row["partenza"],-10} | {row["importo"],-10} | {row["tipo_struttura"],-10}");
            }

            //loads data from database
            return result;
        }

        #endregion

        //Methods to connect to the server

        #region ConnectionDB
        private void ConnectToDB()
        {
            this.connection = new SqlConnection(this.connectionString);
            this.connection.Open();
        }

        #endregion

        //Methods to do INPUT/OUTPUT

        #region INPUT/OUTPUT
        public string GetValueName(string request, string value)
        {
            string result;
            string str;

            do
            {
                Console.WriteLine("Inserisci il nome: ");
                str = Console.ReadLine();
            }
            while (str == " ");

            return result = str;
        }

        public string GetValueSurName(string request, string value)
        {
            string result;
            string str;

            do
            {
                Console.WriteLine("Inserisci il cognome: ");
                str = Console.ReadLine();
            }
            while (str == " ");

            return result = str;
        }

        public int GetValueID(string request, int ID)
        {
            int id;

            do
            {
                Console.WriteLine("Inserisci l'id: ");
                Int32.TryParse(Console.ReadLine(), out id);
            }
            while (id == 0);

            return id;
        }

        #endregion 

    }
}