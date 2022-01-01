using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReportSharp.Models;
using ReportSharp.Reporters;
using ReportSharp.DatabaseReporter.DbContext;

namespace ReportSharp.DatabaseReporter.Reporters.DatabaseReporter
{
    public class DatabaseReporter : IDataReporter, IExceptionReporter, IRequestReporter
    {
        public DatabaseReporter(IServiceScopeFactory scopeFactory)
        {
            ReportSharpDbContext = scopeFactory.CreateScope().ServiceProvider.GetService<ReportSharpDbContext>();
        }

        public ReportSharpDbContext ReportSharpDbContext { get; set; }

        public virtual async Task ReportData(HttpContext httpContext, string tag, string data)
        {
            if (ReportSharpDbContext == null) return;

            await ReportSharpDbContext.AddAsync(new ReportSharpData {
                Tag = tag,
                Data = data
            });
            await ReportSharpDbContext.SaveChangesAsync();
        }

        public virtual async Task ReportException(HttpContext httpContext, ReportSharpRequest request,
            Exception exception)
        {
            if (ReportSharpDbContext == null) return;

            await ReportSharpDbContext.AddAsync(request);
            await ReportSharpDbContext.SaveChangesAsync();
        }

        public virtual async Task ReportRequest(HttpContext httpContext, ReportSharpRequest request)
        {
            if (ReportSharpDbContext == null) return;

            await ReportSharpDbContext.AddAsync(request);
            await ReportSharpDbContext.SaveChangesAsync();
        }
    }
}