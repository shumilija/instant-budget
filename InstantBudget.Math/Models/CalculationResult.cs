namespace InstantBudget.Math.Models
{
	/// <summary>
	/// Результат расчета бюджета.
	/// </summary>
	public class CalculationResult
	{
		/// <summary>
		/// Минимальная сумма денег в условных единицах, которая требуется, чтобы прожить до указанного дня.
		/// </summary>
		public decimal MinAmount { get; set; }

		/// <summary>
		/// Сумма свободных денег в условных единицах сверх минимума.
		/// </summary>
		public decimal FreeAmount { get; set; }
	}
}
