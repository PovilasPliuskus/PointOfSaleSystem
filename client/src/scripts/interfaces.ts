// Company
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

export interface UpdateCompanyRequest {
  id: string;
  code: string;
  name: string;
  updateTime: string;
}

// FullOrder
export interface FullOrderObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  orders: OrderObject[];
  tip: number;
  status: number;
  currency: number;
  totalPrice: number;
}

export interface CreateFullOrderRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  orders: OrderObject[];
  tip: number;
  status: number;
}

export interface UpdateFullOrderRequest {
  id: string;
  tip: number;
  status: number;
  name: string;
  updateTime: string;
}

// Order
export interface OrderObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  establishmentProductId: string;
  establishmentServiceId: string;
  count: number;
  fullOrderId: string;
}

export interface CreateOrderRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  establishmentProductId: string | null;
  establishmentServiceId: string | null;
  count: number;
}

export interface UpdateOrderRequest {
  id: string;
  name: string;
  count: number;
  updateTime: string;
}

// CompanyService
export interface CompanyService {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
}

// CompanyProduct
export interface CompanyProduct {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  alcoholicBeverage: boolean;
}

// Establishment
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

// Employee
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

// EstablishmentProduct
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

// EstablishmentService
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
