namespace InstantBudget.Math.Models
{
	/// <summary>
	/// Запись о финансах (сумма денег наличными, на дебетовой карте, долг по кредитной карте или др).
	/// </summary>
	public class Finance
	{
		/// <summary>
		/// Сумма денег в условных единицах.
		/// </summary>
		public decimal Amount { get; set; }

		/// <summary>
		/// Вид записи (накопления или долги).
		/// </summary>
		public FinanceType Type { get; set; }
	}
}
