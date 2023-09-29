﻿using Wbc.Application.Common.Attributes;

namespace Wbc.Application.Common.Enums
{
    public enum FileFormats
    {
        [StringValue("PDF")]
        Pdf,
        [StringValue("Word")]
        Word,
        [StringValue("Excel")]
        Excel,
        [StringValue("PowerPoint")]
        PowerPoint,
        [StringValue("Image")]
        Image

    }
}
