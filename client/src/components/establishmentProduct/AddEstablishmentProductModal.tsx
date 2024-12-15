import { CurrencyDisplay } from "../../scripts/enums/CurrencyEnum";
import { EstablishmentObject } from "../../scripts/interfaces";

interface AddEstablishmentProductModalProps {
  showModal: boolean;
  newEstablishmentProductPrice: number;
  newEstablishmentProductAmountInStock: number;
  newEstablishmentProductCurrency: number;
  newEstablishmentProductName: string;
  establishments: EstablishmentObject[];

  toggleModal: () => void;
  handleInputChange: (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => void;
  handleSave: () => void;
}

const AddEstablishmentProductModal: React.FC<
  AddEstablishmentProductModalProps
> = ({
  showModal,
  newEstablishmentProductPrice,
  newEstablishmentProductAmountInStock,
  newEstablishmentProductCurrency,
  newEstablishmentProductName,
  establishments,
  toggleModal,
  handleInputChange,
  handleSave,
}) => {
  if (!showModal) return null;
  return (
    <div className="modal fade show" style={{ display: "block" }}>
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Add Establishment Product</h5>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newEstablishmentProductName}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Select Establishment</label>
                <select
                  className="form-select"
                  name="establishmentId"
                  onChange={handleInputChange}
                >
                  <option value="">Select establishment</option>
                  {establishments.map((establishment) => (
                    <option key={establishment.id} value={establishment.id}>
                      {establishment.name}
                    </option>
                  ))}
                </select>
              </div>
              <div className="mb-3">
                <label className="form-label">Currency</label>
                <select
                  className="form-select"
                  name="currency"
                  value={newEstablishmentProductCurrency}
                  onChange={handleInputChange}
                >
                  {Object.entries(CurrencyDisplay).map(([key, value]) => (
                    <option key={key} value={key}>
                      {value}
                    </option>
                  ))}
                </select>
              </div>
              <div className="mb-3">
                <label className="form-label">Price</label>
                <input
                  type="number"
                  className="form-control"
                  name="price"
                  value={newEstablishmentProductPrice}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Amount</label>
                <input
                  type="number"
                  className="form-control"
                  name="amountInStock"
                  value={newEstablishmentProductAmountInStock}
                  onChange={handleInputChange}
                ></input>
              </div>
            </form>
          </div>
          <div className="modal-footer">
            <button
              type="button"
              className="btn btn-secondary"
              onClick={toggleModal}
            >
              Close
            </button>
            <button
              type="button"
              className="btn btn-primary"
              onClick={handleSave}
            >
              Save Changes
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AddEstablishmentProductModal;
