using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Data.Constants;

namespace WebApp.Data.Entities.Base;

public abstract class Entity
{
    public virtual Guid Id { get; set; }

    [Column(TypeName = ColumnTypeName.DateTime2)]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = ColumnTypeName.DateTime2)]
    public DateTime? ModifiedDate { get; set; }

    public int Order { get; set; }

    public int StatusId { get; set; }

    public virtual Status Status { get; set; }

    protected Entity()
    {
        CreatedDate = DateTime.Now.ToLocalTime();
        StatusId = 1;
        Order = 1;
    }
}