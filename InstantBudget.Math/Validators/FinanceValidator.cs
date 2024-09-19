using InstantBudget.Math.Models;

namespace InstantBudget.Math.Validators
{
	/// <summary>
	/// Валидатор для модели <see cref="Finance"/>.
	/// </summary>
	internal static class FinanceValidator
	{
		/// <summary>
		/// Выполнить валидацию указанной модели.
		/// </summary>
		/// <param name="model">Модель для валидации.</param>
		/// <returns>Агрегация всех ошибок, обнаруженных в модели.</returns>
		internal static AggregateException? Validate(Finance model)
		{
			var exceptions = new List<Exception>();

			if (model.Amount <= 0)
			{
				exceptions.Add(new ArgumentException($"'{nameof(Finance.Amount)}': требуется положительное число."));
			}

			if (!Enum.GetValues<FinanceType>().Contains(model.Type))
			{
				exceptions.Add(new ArgumentException($"{model.Type} - неизвестный вид записи о финансах."));
			}

			if (exceptions.Count == 0)
			{
				return null;
			}

			return new AggregateException(exceptions);
		}
	}
}
