﻿namespace Shop.Application.Emails.Options;

public class SendgridOptions
{
    public required RapidOptions Headers { get; set; }
    public required string RequestUri { get; set; }
    public required string ContentType { get; set; }

}
