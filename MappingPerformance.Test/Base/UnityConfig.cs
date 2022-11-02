﻿using MappingPerformance.Interactors.Interactors;
using MediatR;
using System;
using System.Linq;
using System.Reflection;
using Unity;
using PubSub;
using Unity.Lifetime;

namespace MappingPerformance.Test.Base
{
    public static class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetUnityContainer()
        {
            return Container.Value;
        }

        private static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IPubSubPipelineFactory, PubSubPipelineFactory>(new ContainerControlledLifetimeManager());

            // register interactors
            var interactorTypes = typeof(ReadEmployeeWithOutMappingInteractor).Assembly
                                    .GetTypes()
                                    .Select(t => t.GetTypeInfo())
                                    .Where(t => t.ImplementedInterfaces.Any(i =>
                                            i.IsGenericType && i.GetGenericTypeDefinition().IsAssignableFrom(typeof(IRequestHandler<,>))))
                                    .Select(t => new
                                    {
                                        Interface = t.ImplementedInterfaces.First(i => i.IsGenericType && i.GetGenericTypeDefinition().IsAssignableFrom(typeof(IRequestHandler<,>))),
                                        Type = t
                                    });

            foreach (var resolveType in interactorTypes)
                container.RegisterType(resolveType.Interface, resolveType.Type);
        }
    }
}
