using InstantBudget.Math.Models;

namespace InstantBudget.Math.Validators
{
	/// <summary>
	/// Валидатор для модели <see cref="CalculationData"/>.
	/// </summary>
	internal static class CalculationDataValidator
	{
		/// <summary>
		/// Выполнить валидацию указанной модели.
		/// </summary>
		/// <param name="model">Модель для валидации.</param>
		/// <returns>Агрегация всех ошибок, обнаруженных в модели.</returns>
		internal static AggregateException? Validate(CalculationData model)
		{
			var exceptions = new List<Exception>();

			if (model.DayCost <= 0)
			{
				exceptions.Add(new ArgumentException($"'{nameof(CalculationData.DayCost)}': требуется положительное число."));
			}

			if (model.EndDay < model.StartDay)
			{
				exceptions.Add(new ArgumentException($"'{nameof(CalculationData.EndDay)}' не может быть меньше '{nameof(CalculationData.StartDay)}'."));
			}

			exceptions.AddRange(model.Finances
				.Select(FinanceValidator.Validate)
				.Where(e => e != null)!);

			if (exceptions.Count == 0)
			{
				return null;
			}

			return new AggregateException(exceptions);
		}
	}
}
