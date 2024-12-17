export enum EmployeeStatusEnum {
  None = 0,
  Admin = 1,
  CompanyOwner = 2,
  Manager = 3,
  Worker = 4,
}

export const EmployeeStatusDisplay: Record<EmployeeStatusEnum, string> = {
  [EmployeeStatusEnum.None]: "None",
  [EmployeeStatusEnum.Admin]: "Admin",
  [EmployeeStatusEnum.CompanyOwner]: "CompanyOwner",
  [EmployeeStatusEnum.Manager]: "Manager",
  [EmployeeStatusEnum.Worker]: "Worker",
};

export function getEmployeeStatusDisplay(status: number): string {
  return EmployeeStatusDisplay[status as EmployeeStatusEnum] || "Unknown";
}
