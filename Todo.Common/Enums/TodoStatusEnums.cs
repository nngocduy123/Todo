using System;
using System.ComponentModel;

namespace Todo.Common.Enums
{
	public enum TodoStatusEnums
	{
        [Description("On_Track")]
        OnTrack = 1,

		[Description("Off_Track")]
		OffTrack = 2,

        [Description("Expired")]
        Expired = 3,
    }
}

