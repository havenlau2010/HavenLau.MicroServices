
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreDemo.Entity
{
    public interface IEntity
    {
        string Id { get; set; }
    }

    // ʵ����࣬�̳���Ҫָ��ʵ��Table������ᱨ��
    public class BaseEntity : IEntity
    {
        [Key]
        [MaxLength(64)]
        public virtual string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(64)]
        [Required]
        public virtual string TenantId { get; set; } = string.Empty;

        [MaxLength(64)]
        [Required]
        public virtual string UserId { get; set; } = string.Empty;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public virtual DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// ����޸�ʱ��
        /// </summary>
        public virtual DateTime UpdateTime { get; set; } = DateTime.Now;

        public void SetTenancy(string TId, string UId, bool IsUpdate = false)
        {
            TenantId = TId;
            UserId = UId;
            if (!IsUpdate)
            {
                CreateTime = DateTime.Now;
            }
            else
            {
                UpdateTime = DateTime.Now;
            }
        }

    }
}