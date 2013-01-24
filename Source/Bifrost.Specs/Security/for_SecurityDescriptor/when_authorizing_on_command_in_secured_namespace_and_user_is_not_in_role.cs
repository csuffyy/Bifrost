﻿using Bifrost.Security;
using Machine.Specifications;

namespace Bifrost.Specs.Security.for_SecurityDescriptor
{
    [Subject(typeof(SecurityDescriptor))]
    public class when_authorizing_on_command_in_secured_namespace_and_user_is_not_in_role : given.a_configured_security_descriptor
    {
        static AuthorizationResult can_authorize;

        Because of = () => can_authorize = security_descriptor.Authorize(command_that_has_namespace_rule);

        It should_not_be_authorized = () => can_authorize.IsAuthorized.ShouldBeFalse();
    }
}