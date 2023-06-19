using Microsoft.Data.SqlClient;
using System.Data;
namespace EmployeeData.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }

        public static List<Employee> GetEmployeeDetails()
        {
            List<Employee> empList = new List<Employee>();
            SqlConnection con = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJan23;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmdList= new SqlCommand();
                cmdList.Connection = con;
                cmdList.CommandType = CommandType.Text;
                cmdList.CommandText = "select * from Employee";
                SqlDataReader dr = cmdList.ExecuteReader();
                while(dr.Read())
                {
                    empList.Add(new Employee
                    {
                        Id = dr.GetInt32("id"),
                        Name = dr.GetString("Name"),
                        City = dr.GetString("City"),
                        Address = dr.GetString("Address")
                    });
                }
                dr.Close();
                return empList;
            }
            catch
            {
                throw;
            }
            finally { con.Close(); }    
        }

        public static Employee GetEmployee(int id)
        {
            Employee emp = new Employee();  
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJan23;Integrated Security=True";
            try
            {
                con.Open(); 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;   
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employee where Id =@Id";
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    emp.Id= dr.GetInt32("id");
                    emp.Name= dr.GetString("Name");
                    emp.City = dr.GetString("City");
                    emp.Address = dr.GetString("Address");
                }
                dr.Close();
                return emp;

            }
            catch { throw; }
            finally { con.Close(); }
        }

        public static void InsertUserData(Employee obj)
        {
            SqlConnection con= new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJan23;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Employee values (@Id,@Name,@City,@Address)";
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue ("Name", obj.Name);
                cmd.Parameters.AddWithValue("City", obj.City);
                cmd.Parameters.AddWithValue("Address", obj.Address);
                cmd.ExecuteNonQuery();
                
            }
            catch { throw; } finally { con.Close();}

        }

        public static void UpdateUserData(Employee obj) 
        {
            SqlConnection con= new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJan23;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Employee set Id=@Id, Name=@Name, City=@City, Address=@Address where Id=@Id";
                cmd.Parameters.AddWithValue("@Id",obj.Id);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@City", obj.City);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.ExecuteNonQuery();

            }
            catch { throw; } finally { con.Close();}      

        }
        public static void DeleteUserData(Employee obj)
        {
            SqlConnection con= new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJan23;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText= "Delete from Employee where Id = @Id";
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.ExecuteNonQuery();
            }
            catch { throw; } finally { con.Close();}    

        }
    }


}
