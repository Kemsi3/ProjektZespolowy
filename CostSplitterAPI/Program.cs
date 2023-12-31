using CostSplitterAPI.Data;
using CostSplitterAPI.DTO;
using CostSplitterAPI.Models;
using CostSplitterAPI.Services.Bills;
using CostSplitterAPI.Services.Participants;
using CostSplitterAPI.Services.SingleCosts;
using CostSplitterAPI.Services.Transactions;
using CostSplitterAPI.Services.Users;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ISingleCostService, SingleCostService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//logowanie
app.MapPost("/login", async (IUserService userService, UserDTO user) => await userService.Login(user));

//dodanie użytkownika
app.MapPost("/user/", async (IUserService userService, User user) => await userService.AddUser(user));


//dodanie rachunku
app.MapPost("/bill/", async (IBillService billService, Bill bill) => await billService.AddBill(bill));

//dodanie transakcji w rachunku
app.MapPost("/transaction/", async (ITransactionService transactionService, Transaction transaction) => await transactionService.AddTransaction(transaction));

//dodanie uczestnika do rachunku
app.MapPost("/participant/", async (IParticipantService participantService, Participant participant) => await participantService.AddParticipant(participant));

//dodanie pojedynczego kosztu w rachunku
app.MapPost("/singlecost/", async (ISingleCostService singleCostService, SingleCost singleCost) => await singleCostService.AddSingleCost(singleCost));

//pobranie wszystkich rachunkow użytkownika
app.MapGet("/bills/{userId}", async (IBillService billService, Guid userId) => await billService.GetBillsByUserId(userId));

//pobranie pojedynczych kosztów w rachunku
app.MapGet("/singlecosts/{billId}", async (ISingleCostService singleCostService, Guid billId) => await singleCostService.GetSingleCostsByBillId(billId));

//pobranie uczestników w rachunku
app.MapGet("/participants/{billId}", async (IParticipantService participantService, Guid billId) => await participantService.GetParticipantsByBillId(billId));

//pobranie transakcji w rachunku
app.MapGet("/transactions/{billId}", async (ITransactionService transactionService, Guid billId) => await transactionService.GetTransactionsByBillId(billId));

//podzielenie rachunku 
app.MapGet("/splitbill/{billId}", async (IBillService billService, Guid billId) => await billService.SplitBill(billId));

//usuwanie pojedynczego kosztu
app.MapDelete("/singlecost/{singleCostId}", async(ISingleCostService singleCostService, Guid singleCostId) => await singleCostService.DeleteSingleCost(singleCostId));

//usuwanie uczestnika rachunku
app.MapDelete("/participant/{participantId}", async (IParticipantService participantService, Guid participantId) => await participantService.DeleteParticipant(participantId));

//usuwanie transakcji
app.MapDelete("/transaction/{transactionId}", async (ITransactionService transactionService, Guid transactionId) => await transactionService.DeleteTransaction(transactionId));



app.Run();