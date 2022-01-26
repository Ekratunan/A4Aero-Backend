using A4Aero.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace A4Aero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessEntitiesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BusinessEntitiesController(IConfiguration config)
        {
            _configuration = config;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT * FROM dbo.BusinessEntities";


            DataTable dataTable = new();
            DataTable data = dataTable;

            string getDataSource = _configuration.GetConnectionString("BusinessAppCon");
            SqlDataReader reader;
            using (SqlConnection myCon = new(getDataSource))
            {
                myCon.Open();
                using SqlCommand myCmd = new(query, myCon);
                reader = myCmd.ExecuteReader();
                data.Load(reader);
                reader.Close();
                myCon.Close();
            }

            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Post(BusinessEntities b)
        {
            string query = @"INSERT INTO dbo.BusinessEntities (Code,Email,Name,Street,City,State,Zip,Country,Mobile,Phone,ContactPerson,ReferredBy,Logo,Status,Balance,SMTPServer,SMTPPort,SMTPUsername,SMTPPassword,Deleted,CreatedOnUtc,UpdatedOnUtc) VALUES(@Code,@Email,@Name,@Street,@City,@State,@Zip,@Country,@Mobile,@Phone,@ContactPerson,@ReferredBy,@Logo,@Status,@Balance,@SMTPServer,@SMTPPort,@SMTPUsername,@SMTPPassword,@Deleted,@CreatedOnUtc,@UpdatedOnUtc)";

            DataTable data = new();

            string getDataSource = _configuration.GetConnectionString("BusinessAppCon");
            SqlDataReader reader;
            using (SqlConnection myCon = new(getDataSource))
            {
                myCon.Open();
                using SqlCommand myCmd = new(query, myCon);
                myCmd.Parameters.AddWithValue("@Code", b.Code);
                myCmd.Parameters.AddWithValue("@Email", b.Email);
                myCmd.Parameters.AddWithValue("@Name", b.Name);
                myCmd.Parameters.AddWithValue("@Street", b.Street);
                myCmd.Parameters.AddWithValue("@City", b.City);
                myCmd.Parameters.AddWithValue("@State", b.State);
                myCmd.Parameters.AddWithValue("@Zip", b.Zip);
                myCmd.Parameters.AddWithValue("@Country", b.Country);
                myCmd.Parameters.AddWithValue("@Mobile", b.Mobile);
                myCmd.Parameters.AddWithValue("@Phone", b.Phone);
                myCmd.Parameters.AddWithValue("@ContactPerson", b.ContactPerson);
                myCmd.Parameters.AddWithValue("@ReferredBy", b.ReferredBy);
                myCmd.Parameters.AddWithValue("@Logo", b.Logo);
                myCmd.Parameters.AddWithValue("@Status", b.Status);
                myCmd.Parameters.AddWithValue("@Balance", b.Balance);
                myCmd.Parameters.AddWithValue("@SMTPServer", b.SMTPServer);
                myCmd.Parameters.AddWithValue("@SMTPPort", b.SMTPPort);
                myCmd.Parameters.AddWithValue("@SMTPUsername", b.SMTPUsername);
                myCmd.Parameters.AddWithValue("@SMTPPassword", b.SMTPPassword);
                myCmd.Parameters.AddWithValue("@Deleted", b.Deleted);
                myCmd.Parameters.AddWithValue("@CreatedOnUtc", DateTime.UtcNow);
                myCmd.Parameters.AddWithValue("@UpdatedOnUtc", DateTime.UtcNow);

                reader = myCmd.ExecuteReader();
                data.Load(reader);
                reader.Close();
                myCon.Close();
            }

            return new JsonResult("Record Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(BusinessEntities b)
        {
            string query = @"UPDATE dbo.BusinessEntities(Code,Email,Name,Street,City,State,Zip,Country,Mobile,Phone,ContactPerson,ReferredBy,Logo,Status,Balance,SMTPServer,SMTPPort,SMTPUsername,SMTPPassword,Deleted,CreatedOnUtc,UpdatedOnUtc) SET(Code=@Code,Email=@Email,Name=@Name,Street=@Street,City=@City,State=@State,Zip=@Zip,Country=@Country,Mobile=@Mobile,Phone=@Phone,ContactPerson=@ContactPerson,ReferredBy=@ReferredBy,Logo=@Logo,Status=@Status,Balance=@Balance,SMTPServer=@SMTPServer,SMTPPort=@SMTPPort,SMTPUsername=@SMTPUsername,SMTPPassword=@SMTPPassword,Deleted=@Deleted,CreatedOnUtc=@CreatedOnUtc,UpdatedOnUtc=@UpdatedOnUtc) WHERE BusinessId=@BusinessId;";

            DataTable data = new();

            string getDataSource = _configuration.GetConnectionString("BusinessAppCon");
            SqlDataReader reader;
            using (SqlConnection myCon = new(getDataSource))
            {
                myCon.Open();
                using SqlCommand myCmd = new(query, myCon);
                myCmd.Parameters.AddWithValue("@BusinessId", b.BusinessId);
                myCmd.Parameters.AddWithValue("@Code", b.Code);
                myCmd.Parameters.AddWithValue("@Email", b.Email);
                myCmd.Parameters.AddWithValue("@Name", b.Name);
                myCmd.Parameters.AddWithValue("@Street", b.Street);
                myCmd.Parameters.AddWithValue("@City", b.City);
                myCmd.Parameters.AddWithValue("@State", b.State);
                myCmd.Parameters.AddWithValue("@Zip", b.Zip);
                myCmd.Parameters.AddWithValue("@Country", b.Country);
                myCmd.Parameters.AddWithValue("@Mobile", b.Mobile);
                myCmd.Parameters.AddWithValue("@Phone", b.Phone);
                myCmd.Parameters.AddWithValue("@ContactPerson", b.ContactPerson);
                myCmd.Parameters.AddWithValue("@ReferredBy", b.ReferredBy);
                myCmd.Parameters.AddWithValue("@Logo", b.Logo);
                myCmd.Parameters.AddWithValue("@Status", b.Status);
                myCmd.Parameters.AddWithValue("@Balance", b.Balance);
                myCmd.Parameters.AddWithValue("@SMTPServer", b.SMTPServer);
                myCmd.Parameters.AddWithValue("@SMTPPort", b.SMTPPort);
                myCmd.Parameters.AddWithValue("@SMTPUsername", b.SMTPUsername);
                myCmd.Parameters.AddWithValue("@SMTPPassword", b.SMTPPassword);
                myCmd.Parameters.AddWithValue("@Deleted", b.Deleted);
                myCmd.Parameters.AddWithValue("@CreatedOnUtc", b.CtreatedOnUtc);
                myCmd.Parameters.AddWithValue("@UpdatedOnUtc", DateTime.UtcNow);

                reader = myCmd.ExecuteReader();
                data.Load(reader);
                reader.Close();
                myCon.Close();
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = "DELETE FROM BusinessEntities WHERE BusinessId=@BusinessId";

            DataTable data = new DataTable();

            string getDataSource = _configuration.GetConnectionString("BusinessAppCon");
            SqlDataReader reader;
            using (SqlConnection myCon = new(getDataSource))
            {
                myCon.Open();
                using (SqlCommand myCmd = new(query, myCon))
                {
                    myCmd.Parameters.AddWithValue("@BusinessId", id);
                   

                    reader = myCmd.ExecuteReader();
                    data.Load(reader);
                    reader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }

}
