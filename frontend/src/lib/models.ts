export type Id = number;

export interface Location {
  id: Id;
  address?: string;
  city?: string;
  country?: string;
  postalCode?: string;
  createdAt?: string;
}

export interface WorkspaceType {
  id: Id;
  name: string;
  description?: string;
}

export interface Workspace {
  id: Id;
  name?: string;
  description?: string;
  locationId?: Id;
  workspaceTypeId?: Id;
}

export interface Customer {
  id: Id;
  name?: string;
  email?: string;
  phone?: string;
}

export interface Reservation {
  id: Id;
  workspaceId?: Id;
  customerId?: Id;
  startTime?: string;
  endTime?: string;
  status?: string;
}

export interface Payment {
  id: Id;
  amount?: number;
  paymentDate?: string;
  status?: string;
  reservationId?: Id;
}
