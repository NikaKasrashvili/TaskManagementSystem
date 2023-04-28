namespace Infrastructure.DAL.Entities;

public abstract class BaseDomainEntity<Tid>
{
    public Tid Id { get; set; } = default!;
    public DateTime DateCreatedOn { get; set; }
}

