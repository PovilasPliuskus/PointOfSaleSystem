import { FullOrderStatusEnum } from "../../scripts/enums/FullOrderStatusEnum";
import {
  EstablishmentProductObject,
  EstablishmentServiceObject,
  FullOrderObject,
} from "../../scripts/interfaces";
import { useState } from "react";

interface AddOrderModalProps {
  showModal: boolean;
  newOrderName: string;
  newOrderCount: number;
  fullOrders: FullOrderObject[];
  establishmentProducts: EstablishmentProductObject[];
  establishmentServices: EstablishmentServiceObject[];

  toggleModal: () => void;
  handleInputChange: (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => void;
  handleSave: () => void;
}

const AddOrderModal: React.FC<AddOrderModalProps> = ({
  showModal,
  newOrderName,
  newOrderCount,
  fullOrders,
  establishmentProducts,
  establishmentServices,
  toggleModal,
  handleInputChange,
  handleSave,
}) => {
  const [selectionType, setSelectionType] = useState("");

  if (!showModal) return null;

  const handleRadioChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSelectionType(event.target.value);
  };

  return (
    <div className="modal fade show" style={{ display: "block" }}>
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Add New Order</h5>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newOrderName}
                  onChange={handleInputChange}
                />
              </div>

              <div className="mb-3">
                <label className="form-label">Choose Type</label>
                <div>
                  <input
                    type="radio"
                    id="product"
                    name="selectionType"
                    value="product"
                    onChange={handleRadioChange}
                  />
                  <label htmlFor="product" className="form-label ms-2">
                    Product
                  </label>
                </div>
                <div>
                  <input
                    type="radio"
                    id="service"
                    name="selectionType"
                    value="service"
                    onChange={handleRadioChange}
                  />
                  <label htmlFor="service" className="form-label ms-2">
                    Service
                  </label>
                </div>
              </div>

              <div className="mb-3">
                <label className="form-label">Select Product</label>
                <select
                  className="form-select"
                  name="establishmentProductId"
                  onChange={handleInputChange}
                  disabled={selectionType !== "product"}
                >
                  <option value="">Select product</option>
                  {establishmentProducts.map((product) => (
                    <option key={product.id} value={product.id}>
                      {product.name}
                    </option>
                  ))}
                </select>
              </div>

              <div className="mb-3">
                <label className="form-label">Select Service</label>
                <select
                  className="form-select"
                  name="establishmentServiceId"
                  onChange={handleInputChange}
                  disabled={selectionType !== "service"}
                >
                  <option value="">Select service</option>
                  {establishmentServices.map((service) => (
                    <option key={service.id} value={service.id}>
                      {service.name}
                    </option>
                  ))}
                </select>
              </div>

              <div className="mb-3">
                <label className="form-label">Select Full Order</label>
                <select
                  className="form-select"
                  name="fullOrderId"
                  onChange={handleInputChange}
                >
                  <option value="">Select an order</option>
                  {fullOrders
                    .filter(
                      (fullOrder) =>
                        fullOrder.status === FullOrderStatusEnum.Open
                    )
                    .map((fullOrder) => (
                      <option key={fullOrder.id} value={fullOrder.id}>
                        {fullOrder.name}
                      </option>
                    ))}
                </select>
              </div>

              <div className="mb-3">
                <label className="form-label">Count</label>
                <input
                  type="number"
                  className="form-control"
                  name="count"
                  value={newOrderCount}
                  onChange={handleInputChange}
                />
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

export default AddOrderModal;
