﻿namespace Blogi.Application.Features.Contacts.Commands.Delete
{
    public class DeleteContactCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }
}