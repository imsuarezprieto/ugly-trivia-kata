using System;

namespace Trivia
{
	public static class Extensions
	{
		public static TScoped Until<TScoped>(this TScoped @this, Predicate<TScoped> condition, Action<TScoped> scopedBlock)
		{
			if (!condition(@this)) return @this;
			scopedBlock(@this);
			return Until<TScoped>(@this, condition, scopedBlock);
		}
	}
}