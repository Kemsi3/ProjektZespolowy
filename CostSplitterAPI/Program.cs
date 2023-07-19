using CostSplitterAPI.Data;
using CostSplitterAPI.Models;
using CostSplitterAPI.Services.Bills;
using CostSplitterAPI.Services.Participants;
using CostSplitterAPI.Services.SingleCosts;
using CostSplitterAPI.Services.Transactions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ISingleCostService, SingleCostService>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/bill/", async (IBillService billService, Bill bill) => await billService.AddBill(bill));

app.MapPost("/transaction/", async (ITransactionService transactionService, Transaction transaction) => await transactionService.AddTransaction(transaction));

app.MapPost("/participant/", async (IParticipantService participantService, Participant participant) => await participantService.AddParticipant(participant));

app.MapPost("/singlecost/", async (ISingleCostService singleCostService, SingleCost singleCost) => await singleCostService.AddSingleCost(singleCost));
app.Run();