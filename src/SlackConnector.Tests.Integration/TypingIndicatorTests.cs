﻿using System;
using System.Linq;
using NUnit.Framework;
using SlackConnector.Models;
using SlackConnector.Tests.Integration.Configuration;

namespace SlackConnector.Tests.Integration
{
    [TestFixture]
    public class TypingIndicatorTests
    {
        [Test]
        public void should_send_typing_indicator()
        {
            // given
            var config = new ConfigReader().GetConfig();

            var slackConnector = new SlackConnector();
            var connection = slackConnector.Connect(config.Slack.ApiToken).Result;
            SlackChatHub channel = connection.ConnectedChannels().First(x => x.Name.Equals("#general", StringComparison.InvariantCultureIgnoreCase));

            // when
            connection.IndicateTyping(channel).Wait();

            // then
        }
    }
}