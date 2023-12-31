﻿using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Name}")]
public sealed class Location : AggregateRoot<Location>
{
    public Location(string name)
    {
        Name = name;
    }

    public Location()
    {
        Name = null!;
    }

    public string Name { get; set; }

    private readonly List<Connection> _connections = new();
    //private readonly List<Order> _order = new();

    public IReadOnlyCollection<Connection> Connections => _connections.AsReadOnly();
    //public IReadOnlyCollection<Order> Orders => _order.AsReadOnly();

    public Connection AddConnection(Location destination, int distance)
    {
        Connection connection = new(this, destination, distance);

        _connections.Add(connection);

        return connection;
    }
}
