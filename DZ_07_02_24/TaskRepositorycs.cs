using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_07_02_24
{
    internal class TaskRepositorycs
    {
        private readonly string connectionString;
        public TaskRepositorycs(string connectionString)
        {
            this.connectionString=connectionString;
        }
        public void AddTask(TaskModel taskModel)
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                connection.Execute("INSERT INTO [Tasks] ([Title], [Description], [DueDate], [IsCompleted]) " + "VALUES (@Title, @Description, @DueDate, @IsCompleted)", taskModel);
            }
        }
        public void UpdateTask(TaskModel taskModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE [Tasks] SET [Title]=@Title, [Description]=@Description, [DueDate]=@DueDate, [IsCompleted]=@IsCompleted Where [Id]=@Id", taskModel);
            }
        }
        public TaskModel GetTaskById(int taskId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.QueryFirst<TaskModel>("SELECT [Id], [Title], [Description], [DueDate], [IsCompleted] FROM [Tasks] WHERE [Id]=@Id", new { Id=taskId});
            }
        }
        public void DeleteTaskById(int taskId) 
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM [Tasks] WHERE Id=@Id", new { Id=taskId} );
            }
        }

    }
}
