export interface CompanyObject {
  id: string;
  name: string;
  code: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  establishments: Establishment[] | null;
  companyProducts: CompanyProduct[] | null;
  companyServices: CompanyService[] | null;
}

export interface FullOrderObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  orders: Order[];
  tip: number;
  status: number;
}

export interface Order {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  establishmentProductId: string;
  establishmentServiceId: string;
  count: number;
}

export interface CompanyService {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
}

export interface CompanyProduct {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  alcoholicBeverage: boolean;
}

export interface Establishment {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  code: string;
  employees: Employee[] | null;
  establishmentProducts: EstablishmentProduct[] | null;
  establishmentServices: EstablishmentService[] | null;
}

export interface Employee {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  surname: string;
  salary: number;
  status: number;
  loginUsername: string;
  LoginPasswordHashed: string;
}

export interface EstablishmentProduct {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  price: number;
  amountInStock: number;
  currency: number;
}

export interface EstablishmentService {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  price: number;
  currency: number;
}

export interface UpdateCompanyRequest {
  id: string;
  code: string;
  name: string;
  updateTime: string;
}

export interface UpdateFullOrderRequest {
  id: string;
  tip: number;
  status: number;
  name: string;
  updateTime: string;
}
