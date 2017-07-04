using Microsoft.EntityFrameworkCore;

namespace AnonymousQuestions.Repository.Configuration
{
    public abstract class EntityConfiguration
    {
        protected readonly ModelBuilder _modelBuilder;

        public abstract void Configure();

        protected EntityConfiguration(ModelBuilder modelBuilder)
        {
            this._modelBuilder = modelBuilder;
        }
    }
}
