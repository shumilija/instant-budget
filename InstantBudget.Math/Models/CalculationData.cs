namespace InstantBudget.Math.Models
{
	/// <summary>
	/// Данные для расчета бюджета.
	/// </summary>
	public class CalculationData
	{
		/// <summary>
		/// Сумма денег в условных единицах, необходимая, чтобы прожить день.
		/// </summary>
		public decimal DayCost { get; set; }

		/// <summary>
		/// День начала расчета.
		/// </summary>
		public DateOnly StartDay { get; set; }

		/// <summary>
		/// День окончания расчета.
		/// </summary>
		public DateOnly EndDay { get; set; }

		/// <summary>
		/// Записи об имеющихся в данных момент финансах.
		/// </summary>
		public IEnumerable<Finance> Finances { get; set; } = Enumerable.Empty<Finance>();
	}
}
