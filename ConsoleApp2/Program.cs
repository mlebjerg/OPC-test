// Copyright (c) Converter Systems LLC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Workstation.ServiceModel.Ua;
using Workstation.ServiceModel.Ua.Channels;

namespace ConsoleApp2
{
    internal class Program 
    {
        private static LoggerFactory loggerFactory;
        private static ApplicationDescription appDescription;
        private static UaApplication application;
        private static UaTcpSessionChannel channel;
        private static string discoveryUrl;

        private static void Main(string[] args)
        {
            try
            {
                Task.Run(TestAsync).GetAwaiter().GetResult();

                startUaApp();
                MainViewModel main = new MainViewModel();
                while (true)
                {
                   Thread.Sleep(1000);
                    Console.WriteLine(main.ProgramCubeAdminProdProcessedCount);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to close the program...");
                Console.ReadKey(true);
            }


        }

        public static async Task startUaApp()
        {
            application = new UaApplicationBuilder()
                .SetApplicationUri(appDescription.ApplicationUri)
                .SetDirectoryStore(Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Workstation.UaClient",
                    "pki"))
                .SetIdentity(Program.channel.UserIdentity)
                .SetLoggerFactory(loggerFactory)
                .AddMappedEndpoint(discoveryUrl, channel.RemoteEndpoint)
                .Build();
            application.Run();
            await application.GetChannelAsync(discoveryUrl, new CancellationToken());
        }

        private static async Task TestAsync()
        {
            UaApplication application = null;

            loggerFactory = new LoggerFactory();
            loggerFactory.AddDebug(LogLevel.Trace);

            discoveryUrl = "opc.tcp://localhost:4840";

            Console.WriteLine("Step 1 - Describe this app.");
            appDescription = new ApplicationDescription()
            {
                ApplicationName = "MyHomework",
                ApplicationUri = $"urn:{System.Net.Dns.GetHostName()}:MyHomework",
                ApplicationType = ApplicationType.Client,
            };

            Console.WriteLine("Step 2 - Create a certificate store.");
            var certificateStore = new DirectoryStore(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Workstation.ConsoleApp", "pki"));

            Console.WriteLine("Step 3 - Create a session with your server.");
            channel = new UaTcpSessionChannel(
                appDescription,
                certificateStore,
                ShowSignInDialog,
                discoveryUrl,
                loggerFactory: loggerFactory);
            try
            {
                await channel.OpenAsync();

                Console.WriteLine($"  Opened channel with endpoint '{channel.RemoteEndpoint.EndpointUrl}'.");
                Console.WriteLine($"  SecurityPolicyUri: '{channel.RemoteEndpoint.SecurityPolicyUri}'.");
                Console.WriteLine($"  SecurityMode: '{channel.RemoteEndpoint.SecurityMode}'.");
                Console.WriteLine($"  SecurityLevel: '{channel.RemoteEndpoint.SecurityLevel}'.");
                Console.WriteLine($"  UserIdentityTokens: '{channel.RemoteEndpoint.UserIdentityTokens}'.");
                Console.WriteLine($"  UserIdentity: '{channel.UserIdentity}'.");
                Console.WriteLine($"channel.ServerUris:{channel.RemoteEndpoint}");
                Console.WriteLine($"channel.ServerUris:{channel.ServerUris}");

                Console.WriteLine("Step 4 - Browse the server namespace.");
                Console.WriteLine("+ Root");
                //BrowseRequest browseRequest = new BrowseRequest
                //{
                //    NodesToBrowse = new BrowseDescription[]
                //    {
                //        new BrowseDescription
                //        {
                //            NodeId = NodeId.Parse(ObjectIds.RootFolder), BrowseDirection = BrowseDirection.Forward,
                //            ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences),
                //            NodeClassMask = (uint) NodeClass.Variable | (uint) NodeClass.Object |
                //                            (uint) NodeClass.Method,
                //            IncludeSubtypes = true, ResultMask = (uint) BrowseResultMask.All
                //        }
                //    },
                //};
                //BrowseResponse browseResponse = await channel.BrowseAsync(browseRequest);
                //foreach (var rd1 in browseResponse.Results[0].References ?? new ReferenceDescription[0])
                //{
                //    Console.WriteLine("  + {0}: {1}, {2}", rd1.DisplayName, rd1.BrowseName, rd1.NodeClass);
                //    browseRequest = new BrowseRequest
                //    {
                //        NodesToBrowse = new BrowseDescription[]
                //        {
                //            new BrowseDescription
                //            {
                //                NodeId = ExpandedNodeId.ToNodeId(rd1.NodeId, channel.NamespaceUris),
                //                BrowseDirection = BrowseDirection.Forward,
                //                ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences),
                //                NodeClassMask = (uint) NodeClass.Variable | (uint) NodeClass.Object |
                //                                (uint) NodeClass.Method,
                //                IncludeSubtypes = true, ResultMask = (uint) BrowseResultMask.All
                //            }
                //        },
                //    };
                //    browseResponse = await channel.BrowseAsync(browseRequest);
                //    foreach (var rd2 in browseResponse.Results[0].References ?? new ReferenceDescription[0])
                //    {
                //        Console.WriteLine("    + {0}: {1}, {2}", rd2.DisplayName, rd2.BrowseName, rd2.NodeClass);
                //        browseRequest = new BrowseRequest
                //        {
                //            NodesToBrowse = new BrowseDescription[]
                //            {
                //                new BrowseDescription
                //                {
                //                    NodeId = ExpandedNodeId.ToNodeId(rd2.NodeId, channel.NamespaceUris),
                //                    BrowseDirection = BrowseDirection.Forward,
                //                    ReferenceTypeId = NodeId.Parse(ReferenceTypeIds.HierarchicalReferences),
                //                    NodeClassMask = (uint) NodeClass.Variable | (uint) NodeClass.Object |
                //                                    (uint) NodeClass.Method,
                //                    IncludeSubtypes = true, ResultMask = (uint) BrowseResultMask.All
                //                }
                //            },
                //        };
                //        browseResponse = await channel.BrowseAsync(browseRequest);
                //        foreach (var rd3 in browseResponse.Results[0].References ?? new ReferenceDescription[0])
                //        {
                //            Console.WriteLine("      + {0}: {1}, {2}", rd3.DisplayName, rd3.BrowseName, rd3.NodeClass);
                //        }
                //    }
                //}
                //Console.WriteLine("test");
                //Console.WriteLine("Step 5 - Create a subscription.");
                //var subscriptionRequest = new CreateSubscriptionRequest
                //{
                //    RequestedPublishingInterval = 500,
                //    RequestedMaxKeepAliveCount = 10,
                //    RequestedLifetimeCount = 30,
                //    PublishingEnabled = true
                //};
                //var subscriptionResponse = await channel.CreateSubscriptionAsync(subscriptionRequest);
                //var id = subscriptionResponse.SubscriptionId;

                //Console.WriteLine("Step 6 - Add items to the subscription.");
                //var itemsToCreate = new MonitoredItemCreateRequest[]
                //{
                //    new MonitoredItemCreateRequest
                //    {
                //        ItemToMonitor = new ReadValueId
                //        {
                //            NodeId = NodeId.Parse("ns=6;s=::Program:Cube.Admin.ProdProcessedCount"),
                //            AttributeId = AttributeIds.Value
                //        },
                //        MonitoringMode = MonitoringMode.Reporting,
                //        RequestedParameters = new MonitoringParameters
                //            {ClientHandle = 1, SamplingInterval = -1, QueueSize = 0, DiscardOldest = true}
                //    }
                //};
                //var itemsRequest = new CreateMonitoredItemsRequest
                //{
                //    SubscriptionId = id,
                //    ItemsToCreate = itemsToCreate,
                //};
                //var itemsResponse = await channel.CreateMonitoredItemsAsync(itemsRequest);

                //Console.WriteLine("Step 7 - Subscribe to PublishResponse stream.");
                //var token = channel.Where(pr => pr.SubscriptionId == id).Subscribe(pr =>
                //{
                //    // loop thru all the data change notifications
                //    var dcns = pr.NotificationMessage.NotificationData.OfType<DataChangeNotification>();
                //    foreach (var dcn in dcns)
                //    {
                //        foreach (var min in dcn.MonitoredItems)
                //        {
                //            Console.WriteLine(
                //                $"sub: {pr.SubscriptionId}; handle: {min.ClientHandle}; value: {min.Value}");
                           
                //        }
                //    }
                //});
              
                //Console.WriteLine("Press any key to delete the subscription...");
                //while (!Console.KeyAvailable)
                //{
                //    await Task.Delay(500);
                //}

                //Console.ReadKey(true);

                //    Console.WriteLine("Step 8 - Delete the subscription.");
                //    var request = new DeleteSubscriptionsRequest
                //    {
                //        SubscriptionIds = new uint[] {id}
                //    };
                //    await channel.DeleteSubscriptionsAsync(request);
                //    //token.Dispose();

                //    Console.WriteLine("Press any key to close the session...");
                //    Console.ReadKey(true);

                //    Console.WriteLine("Step 9 - Close the session.");
                await channel.CloseAsync();
            }
            catch (ServiceResultException ex)
            {
                if ((uint)ex.HResult == StatusCodes.BadSecurityChecksFailed)
                {
                    Console.WriteLine("Error connecting to endpoint. Did the server reject our certificate?");
                }

                await channel.AbortAsync();
                throw;
            }
          
        }


        private static async Task<IUserIdentity> ShowSignInDialog(EndpointDescription endpoint)
        {
            IUserIdentity userIdentity = null;
            //if (endpoint.UserIdentityTokens.Any(p => p.TokenType == UserTokenType.Anonymous))
            //{
            //    userIdentity = new AnonymousIdentity();
            //}
            //else if (endpoint.UserIdentityTokens.Any(p => p.TokenType == UserTokenType.UserName))
            //{
            Console.WriteLine("Server is requesting UserName identity...");
            Console.Write("Enter user name: ");
            var userName = "sdu"; //Console.ReadLine();
            Console.Write("Enter password: ");
            var password = "1234"; //Console.ReadLine();
            userIdentity = new UserNameIdentity(userName, password);
            //}
            //else
            //{
            //    Console.WriteLine("Program supports servers requesting Anonymous and UserName identity.");
            //}

            return userIdentity;
        }
    }    
}

