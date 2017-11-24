using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_CL
{
    public static class MyDatabase
    {
        private static OleDbConnection myOleDbConnection = null;
        private static OleDbTransaction trans = null;
        private static string _select = "SELECT * FROM ";
        private static string _sqlStatementGetBenutzer = _select + "Benutzer";
        private static string _sqlStatementGetLager = _select + "Lager";
        private static string _sqlStatementGetRegal = "SELECT RID, maxEbene, t.x, t.y FROM Regal r, Table(SDO_Util.GetVertices(r.shape)) t";
        private static string _sqlStatementGetEbene = _select + "Ebene";
        private static string _sqlStatementGetProdukt = _select + "Produkt";
        private static string _sqlStatementGetAuslagern = _select + "Auslagern";
        private static string _sqlStatementGetEinlagern = _select + "Einlagern";
        private static string internIP = "192.168.128.152";
        private static string externIP = "212.152.179.117";
        private static string IPtoUse;
        private static IDbCommand _selectCmd = null;
        private static IDataReader _reader = null;
        public static List<string> MyPersonNames { get; private set; }

        public static bool isConnected()
        {
            if (myOleDbConnection == null)
                return false;

            return myOleDbConnection.State == ConnectionState.Open;
        }

        public static IDataReader GetBenutzerReader()
        {
            _selectCmd = new OleDbCommand(_sqlStatementGetBenutzer, myOleDbConnection);

            _selectCmd.Transaction = trans;
            _reader = _selectCmd.ExecuteReader();

            return _reader;
        }

        public static IDataReader GetEinlagernReader()
        {
            _selectCmd = new OleDbCommand(_sqlStatementGetEinlagern, myOleDbConnection);

            _selectCmd.Transaction = trans;
            _reader = _selectCmd.ExecuteReader();

            return _reader;
        }
        public static IDataReader GetAuslagernReader()
        {
            _selectCmd = new OleDbCommand(_sqlStatementGetAuslagern, myOleDbConnection);

            _selectCmd.Transaction = trans;
            _reader = _selectCmd.ExecuteReader();

            return _reader;
        }
        public static bool isTransactionOpen()
        {
            return trans.Connection != null;
        }

        public static int insertValuesIntoProdukt(Produkt neuesProdukt)
        {
            int insertedRows = 0;
            // BEISPIEL INSERT
            // INSERT INTO Produkt VALUES ('L1-R1-E1-P1', 'Seide', 10, 2, 'L1-R1-E1');

            string sqlInsert = "INSERT INTO Produkt VALUES ('" + neuesProdukt.PID + "', '" + neuesProdukt.Name
                + "', " + neuesProdukt.Menge + ", " + neuesProdukt.PreisProEinheit + ", '" + neuesProdukt.MeineEbene.EID + "')";
            
            OleDbCommand insertCmd = new OleDbCommand(sqlInsert, myOleDbConnection);
            insertCmd.Transaction = trans;

            insertedRows = insertCmd.ExecuteNonQuery();

            return insertedRows;
        }

        
        public static IDataReader GetLagerReader()
        {
            _selectCmd = new OleDbCommand(_sqlStatementGetLager, myOleDbConnection);

            _selectCmd.Transaction = trans;
            _reader = _selectCmd.ExecuteReader();

            return _reader;
        }

        public static IDataReader GetRegalReader()
        {
            _selectCmd = new OleDbCommand(_sqlStatementGetRegal, myOleDbConnection);

            _selectCmd.Transaction = trans;
            _reader = _selectCmd.ExecuteReader();

            return _reader;
        }

        public static IDataReader GetEbeneReader()
        {
            _selectCmd = new OleDbCommand(_sqlStatementGetEbene, myOleDbConnection);

            _selectCmd.Transaction = trans;
            _reader = _selectCmd.ExecuteReader();

            return _reader;
        }

        public static IDataReader GetProduktReader()
        {
            _selectCmd = new OleDbCommand(_sqlStatementGetProdukt, myOleDbConnection);

            _selectCmd.Transaction = trans;
            _reader = _selectCmd.ExecuteReader();

            return _reader;
        }

        /// <summary>
        /// Fügt Daten in Auslagern und aktualisiert die Menge des Produktes
        /// </summary>
        /// <param name="sqlCmd"></param>
        /// <returns>Die Anzahl der betroffenen Zeilen für den insert</returns>
        public static int InsertIntoAuslagern(Auslagern zuAuslagern)
        {
            int insertedRows = 0;
            // BEISPIEL INSERT
            // INSERT INTO Auslagern VALUES (TO_DATE('03.11.2017 14:02:44', 'dd.mm.yyyy hh24:mi:ss'), 2, 3, 'admin@gmail.com', 'L1-R1-E1-P1');

            string sqlCommand = "INSERT INTO Auslagern VALUES (TO_DATE('" + DateTime.Now + "', 'dd.mm.yyyy hh24:mi:ss'), " + zuAuslagern.Menge
                + ", " + zuAuslagern.Preis + ", '" + zuAuslagern.MeinBenutzer + "', '" +zuAuslagern.MeinProdukt.PID + "')";

            string sqlCommandUpdate = "UPDATE Produkt SET Menge=Menge-" + zuAuslagern.Menge + " WHERE PID='"+ zuAuslagern.MeinProdukt.PID + "'";

            OleDbCommand insertCmd = new OleDbCommand(sqlCommand, myOleDbConnection);
            insertCmd.Transaction = trans;

            insertedRows = insertCmd.ExecuteNonQuery();

            insertCmd = new OleDbCommand(sqlCommandUpdate, myOleDbConnection);
            insertCmd.Transaction = trans;
            insertedRows += insertCmd.ExecuteNonQuery();

            return insertedRows;
        }

        /// <summary>
        /// Fügt Daten in Auslagern und aktualisiert die Menge des Produktes
        /// </summary>
        /// <param name="sqlCmd"></param>
        /// <returns>Die Anzahl der betroffenen Zeilen für den insert</returns>
        public static int InsertIntoEinlagern(Einlagern zuEinlagern)
        {
            int insertedRows = 0;
            // BEISPIEL INSERT
            // INSERT INTO Einlagern VALUES (TO_DATE('03.11.2017 14:02:44', 'dd.mm.yyyy hh24:mi:ss'), 2, 3, 'admin@gmail.com', 'L1-R1-E1-P1');

            string sqlCommand = "INSERT INTO Einlagern VALUES (TO_DATE('" + DateTime.Now + "', 'dd.mm.yyyy hh24:mi:ss'), " + zuEinlagern.Menge
                + ", " + zuEinlagern.Preis + ", '" + zuEinlagern.MeinBenutzer + "', '" + zuEinlagern.MeinProdukt.PID + "')";

            string sqlCommandUpdate = "UPDATE Produkt SET Menge=Menge+" + zuEinlagern.Menge + " WHERE PID='" + zuEinlagern.MeinProdukt.PID + "'";

            OleDbCommand insertCmd = new OleDbCommand(sqlCommand, myOleDbConnection);
            insertCmd.Transaction = trans;

            insertedRows = insertCmd.ExecuteNonQuery();

            insertCmd = new OleDbCommand(sqlCommandUpdate, myOleDbConnection);
            insertCmd.Transaction = trans;

            insertedRows += insertCmd.ExecuteNonQuery();

            return insertedRows;
        }

        /// <summary>
        /// If isSerializable is false, it starts the transaction in read committed
        /// </summary>
        /// <param name="isSerializable"></param>
        public static void Connect(bool isSerializable)
        {
            try
            {
                IPtoUse = internIP;

                string connectionString = "Provider=OraOLEDB.Oracle; " +
                "Data Source=" + IPtoUse + "/ora11g; " +
                "User ID = d5a01; Password = d5a; OLEDB.NET=True;";

                myOleDbConnection = new OleDbConnection(connectionString);
                myOleDbConnection.Open();
                startTransaction(isSerializable);
            }
            catch (Exception ex)
            {
                throw new Exception("Can`t connect to Database: " + ex.Message);
            }
        }

        /// <summary>
        /// If isSerializable is false, it starts the transaction in read committed
        /// </summary>
        /// <param name="isSerializable"></param>
        public static void startTransaction(bool isSerializable)
        {
            if (myOleDbConnection.State == ConnectionState.Open)
                trans = myOleDbConnection.BeginTransaction(isSerializable ? IsolationLevel.Serializable : IsolationLevel.ReadCommitted);
            else
                throw new Exception("Connection is " + myOleDbConnection.State.ToString());
        }

        public static void Close()
        {
            try
            {
                trans.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Connection couldn't be closed. ErrMsg: " + ex.Message);
            }
            try
            {
                myOleDbConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Connection couldn't be closed. ErrMsg: " + ex.Message);
            }
        }

        public static void Commit()
        {
            trans.Commit();
        }

        public static void Rollback()
        {
            trans.Rollback();
        }
    }
}
