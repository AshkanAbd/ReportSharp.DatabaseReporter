using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReportSharp.Builder.ReporterOptionsBuilder;
using ReportSharp.DatabaseReporter.DbContext;

namespace ReportSharp.DatabaseReporter.Builder.ReporterOptionsBuilder.DatabaseOptionsBuilder
{
    public class DatabaseReportOptionsBuilder<TDbContext> :
        IDataReporterOptionsBuilder<Reporters.DatabaseReporter.DatabaseReporter>,
        IExceptionReporterOptionsBuilder<Reporters.DatabaseReporter.DatabaseReporter>,
        IRequestReporterOptionsBuilder<Reporters.DatabaseReporter.DatabaseReporter>
        where TDbContext : ReportSharpDbContext
    {
        private Action<DbContextOptionsBuilder> _optionsBuilder;

        public void Build(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<TDbContext>(_optionsBuilder);
        }

        public DatabaseReportOptionsBuilder<TDbContext> SetOptionsBuilder(
            Action<DbContextOptionsBuilder> optionsBuilder
        )
        {
            _optionsBuilder = optionsBuilder;

            return this;
        }
    }
}