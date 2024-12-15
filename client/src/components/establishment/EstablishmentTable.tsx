import React from "react";
import { EstablishmentObject } from "../../scripts/interfaces";
import EstablishmentExpandedRowDetails from "./EstablishmentExpandedRowDetails";

interface EstablishmentTableProps {
  establishments: EstablishmentObject[];
  paginatedEstablishments: EstablishmentObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedEstablishment: EstablishmentObject | null;

  handleRowClick: (index: number, establishmentId: string) => void;
  handleEditClick: (establishmentId: string) => void;
  handleDeleteClick: (establishmentId: string) => void;
}

const EstablishmentTable: React.FC<EstablishmentTableProps> = ({
  establishments,
  paginatedEstablishments,
  currentPage,
  pageSize,
  expandedRow,
  selectedEstablishment,
  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Establishment Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedEstablishments.map((establishment, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={establishment.id}>
              <tr
                onClick={() => handleRowClick(globalIndex, establishment.id)}
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{establishment.name}</td>
              </tr>

              {expandedRow === globalIndex && establishment && (
                <EstablishmentExpandedRowDetails
                  selectedEstablishment={establishment}
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

export default EstablishmentTable;
