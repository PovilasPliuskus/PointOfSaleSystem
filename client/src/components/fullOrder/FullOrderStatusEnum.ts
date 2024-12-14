export enum FullOrderStatusEnum {
  None = 0,
  Open = 1,
  Closed = 2,
  Cancelled = 3,
  Refunded = 4,
}

export const FullOrderStatusDisplay: Record<FullOrderStatusEnum, string> = {
  [FullOrderStatusEnum.None]: "None",
  [FullOrderStatusEnum.Open]: "Open",
  [FullOrderStatusEnum.Closed]: "Closed",
  [FullOrderStatusEnum.Cancelled]: "Cancelled",
  [FullOrderStatusEnum.Refunded]: "Refunded",
};

export function getFullOrderStatusDisplay(status: number): string {
  return FullOrderStatusDisplay[status as FullOrderStatusEnum] || "Unknown";
}
