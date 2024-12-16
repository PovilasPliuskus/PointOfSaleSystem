import React from "react";
import { EstablishmentServiceObject } from "../../scripts/interfaces";
import EstablishmentServiceExpandedRowDetails from "./EstablishmentServiceExpandedRowDetails";

interface EstablishmentProductTableProps {
  establishmentServices: EstablishmentServiceObject[];
  paginatedEstablishmentServices: EstablishmentServiceObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedEstablishmentService: EstablishmentServiceObject | null;

  handleRowClick: (index: number, establishmentServiceId: string) => void;
  handleEditClick: (establishmentServiceId: string) => void;
  handleDeleteClick: (establishmentServiceId: string) => void;
}

const EstablishmentServiceTable: React.FC<EstablishmentProductTableProps> = ({
  establishmentServices,
  paginatedEstablishmentServices,
  currentPage,
  pageSize,
  expandedRow,
  selectedEstablishmentService,
  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Establishment Service Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedEstablishmentServices.map((establishmentService, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={establishmentService.id}>
              <tr
                onClick={() =>
                  handleRowClick(globalIndex, establishmentService.id)
                }
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{establishmentService.name}</td>
              </tr>

              {expandedRow === globalIndex && selectedEstablishmentService && (
                <EstablishmentServiceExpandedRowDetails
                  selectedEstablishmentService={selectedEstablishmentService}
                  onEdit={handleEditClick}
                  onDelete={handleDeleteClick}
                />
              )}
            </React.Fragment>
          );
        })}
      </tbody>
    </table>
  );
};

export default EstablishmentServiceTable;
