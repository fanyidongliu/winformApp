using AutoMapper;

namespace LK.Infrastructure.Common
{
    public static class AutoMapperExtend
    {
        public static void IgnoreSourceNullMember<TSource, TDestination>(this IMappingExpression<TSource, TDestination> ext)
        {
            ext.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}