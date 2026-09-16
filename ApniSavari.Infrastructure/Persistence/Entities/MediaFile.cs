using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class MediaFile
{
    public long MediaFileId { get; set; }

    public string? OwnerType { get; set; }

    public long? OwnerId { get; set; }

    public string? FileType { get; set; }

    public string? StorageKey { get; set; }

    public string? OriginalFileName { get; set; }

    public string? MimeType { get; set; }

    public string Status { get; set; } = null!;

    public long CreatedByUserId { get; set; }

    public DateTime CreatedAtUtc { get; set; }
}
