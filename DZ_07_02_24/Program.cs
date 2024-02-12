using DZ_07_02_24;

TaskRepositorycs taskRepositorycs= new TaskRepositorycs("Server=LIBERTY; Database=DZ_07_02_24; Trusted_Connection=True; TrustServerCertificate=True; Integrated Security=True;");

//taskRepositorycs.AddTask(
//    new TaskModel
//{ 
//    Title="Task1",
//    Description="Description1",
//    DueDate=DateTime.Now.AddDays(5),
//    IsCompleted=false
//});

//var currentTask = taskRepositorycs.GetTaskById(1);

//taskRepositorycs.UpdateTask(currentTask);
taskRepositorycs.DeleteTaskById(1);


