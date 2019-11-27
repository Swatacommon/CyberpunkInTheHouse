using Oracle.ManagedDataAccess.Client;

namespace CyberConnectedLayer
{
    public static class CyberDAL
    {
        public static  OracleConnection connection;
        public static OracleCommand command;

        public static void OpenConnection(string user_ID, string password, string dbaPrivilege)
        {
            connection = new OracleConnection();
            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
            ocsb.UserID = user_ID;
            ocsb.Password = password;
            ocsb.DBAPrivilege = dbaPrivilege;
            ocsb.DataSource = "172.20.10.12:1521/orcl";
            connection.ConnectionString = ocsb.ConnectionString;
            connection.Open();
        }

        public static OracleDataReader Authorized(string Email)
        {
            command = new OracleCommand("AUTHORIZATION", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("PEMAIL", "NUMBER").Value = Email;
            return command.ExecuteReader();
        }

        public static void Registration(int roleID, string lastName,string firstName,string email, string password, int telephone, string adres)
        {
            command = new OracleCommand("ADDUSER", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("PCLIENTROLEID", "NUMBER").Value = roleID;
            CyberDAL.command.Parameters.Add("PLASTNAME", "VARCHAR2").Value = lastName;
            CyberDAL.command.Parameters.Add("PEMAIL", "VARCHAR2").Value = email;
            CyberDAL.command.Parameters.Add("PPASSWORD", "VARCHAR2").Value = password;
            CyberDAL.command.Parameters.Add("PTELEPHONE", "NUMBER").Value = telephone;
            CyberDAL.command.Parameters.Add("PADRES", "VARCHAR2").Value = adres;
        }

        public static OracleDataReader ShowUsers()
        {
            command = new OracleCommand("SHOWUSER", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            return command.ExecuteReader();
        }

        public static void CloseConnection()
        {
            connection.Close();
        }
    }
}
