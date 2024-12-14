export enum CurrencyEnum {
  None = 0,
  EUR = 1,
  USD = 2,
}

export const CurrencyDisplay: Record<CurrencyEnum, string> = {
  [CurrencyEnum.None]: "None",
  [CurrencyEnum.EUR]: "EUR",
  [CurrencyEnum.USD]: "USD",
};

export function getCurrencyDisplay(currency: number): string {
  return CurrencyDisplay[currency as CurrencyEnum] || "Unknown";
}
