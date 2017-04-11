## Message Bus samples

This repository contains several examples showing a message bus architecture for .NET/.NET Core. 
For a detailed explaination of the message bus architecture please visit https://msdn.microsoft.com/en-us/library/ff647328.aspx.
All demos were used as examples during a presentation.

Libraries used
* [MassTransit](http://masstransit-project.com/)
* [Rebus](https://github.com/rebus-org/Rebus)
* [Shuttle.esb](https://github.com/Shuttle/shuttle-esb)

Demos

* [Demo 1 - Chat](/Demo1-Chat) - Little beginner demo using Shuttle.esb and MSMQ
* [Demo 1 - Chat (REbus)](/Demo1-Chat_Rebus) - Same demo as above but using Rebus and MSMQ
* [Demo 2 - Beer market](/Demo2-Beer_Market) - Beer trading using Rebus and MSMQ
* [Demo 2 - Beer market with Saga](/Demo2-Beer_Market_Saga) - Beer trading using a process manager ("Saga")
* [Demo 3 - CQRS](/Demo3-CQRS) - Sample CQRS architecture using MassTransit and RabbitMQ
* [Demo 4 - Scalability](/Demo4-Scalability) - Demo showing the scalability options using a message bus

I recommend using the [SwitchStartupProject](https://marketplace.visualstudio.com/items?itemName=vs-publisher-141975.SwitchStartupProjectforVS2017) extension to easily start multiple projects. Configuration file is also available for each demo.

#### Presentation
The according slides can be found [here](/MessageBus.pptx). Sorry was for a german audience.
