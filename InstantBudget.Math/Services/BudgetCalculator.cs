using InstantBudget.Math.Models;
using InstantBudget.Math.Validators;

namespace InstantBudget.Math.Services
{
	/// <summary>
	/// Сервис расчета бюджета.
	/// </summary>
	public static class BudgetCalculator
	{
		/// <summary>
		/// Расчитать бюджет по предоставленным данным.
		/// </summary>
		/// <param name="model">Данные для расчета бюджета.</param>
		/// <returns>Результат расчета бюджета.</returns>
		public static CalculationResult Calculate(CalculationData model)
		{
			var exception = CalculationDataValidator.Validate(model);
			if (exception != null)
			{
				throw exception;
			}

			var minAmount = GetMinAmount(model.StartDay, model.EndDay, model.DayCost);
			var freeAmount = GetFreeAmount(model.Finances, minAmount);

			var result = new CalculationResult
			{
				MinAmount = minAmount,
				FreeAmount = freeAmount,
			};

			return result;
		}

		private static decimal GetMinAmount(DateOnly startDay, DateOnly endDay, decimal dayCost)
		{
			var days = 1 + (endDay.DayNumber - startDay.DayNumber);

			var result = days * dayCost;

			return result;
		}

		private static decimal GetFreeAmount(IEnumerable<Finance> finances, decimal minAmount)
		{
			var totalAmount = finances.Sum(r => r.Type == FinanceType.Savings ? r.Amount : -r.Amount);

			var result = totalAmount - minAmount;

			return result;
		}
	}
}
