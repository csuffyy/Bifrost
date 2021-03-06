﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using Bifrost.Security;
using Bifrost.Testing.Fakes.Commands;
using Machine.Specifications;

namespace Bifrost.Specs.Security.for_SecurityDescriptor
{
    [Subject(typeof(BaseSecurityDescriptor))]
    public class when_authorizing_on_command_type_and_namespace_and_user_is_in_only_namespace_role : given.a_configured_security_descriptor
    {
        static AuthorizeDescriptorResult authorize_descriptor_result;
        static IEnumerable<string> authorization_messages;

        Establish context = () =>
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(""), new[]
                    {
                        Testing.Fakes.Security.SecurityDescriptor.NAMESPACE_ROLE
                    });
            };

        Because of = () =>
            {
                authorize_descriptor_result = security_descriptor.Authorize(command_that_has_namespace_and_type_rule);
                authorization_messages = authorize_descriptor_result.BuildFailedAuthorizationMessages();
            };

        It should_not_be_authorized = () => authorize_descriptor_result.IsAuthorized.ShouldBeFalse();
        It should_indicate_that_the_user_is_not_in_the_required_role = () => authorization_messages.First().IndexOf(Testing.Fakes.Security.SecurityDescriptor.SIMPLE_COMMAND_ROLE).ShouldBeGreaterThan(0);
        It should_indicate_the_secured_type = () => authorization_messages.First().IndexOf(typeof(SimpleCommand).FullName).ShouldBeGreaterThan(0);
    }
}