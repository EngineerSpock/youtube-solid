from enum import Enum, auto
from random import randint


class PaymentMethod(Enum):
    CreditCard = auto(),
    Cash = auto()


class PaymentDetails:
    def __init__(self, method: PaymentMethod):
        self.method = method


class TicketDetails:
    def __init__(self, price):
        self.price = price


class ProcessingCenterGateway:
    def charge(self, price, payment):
        pass  # charging process


class PaymentModel:

    def buy_ticket(self, ticket: TicketDetails, payment: PaymentDetails, on_pay_change_to_mobile_phone):
        if payment.method == PaymentMethod.CreditCard:
            self.charge_card(ticket, payment)
        else:
            self.accept_cash(ticket)
            self.dispense_change(ticket, on_pay_change_to_mobile_phone)

    def charge_card(self, ticket, payment):
        gateway = ProcessingCenterGateway()
        gateway.charge(ticket.price, payment)

    def accept_cash(self, ticket):
        self._cash_accepted = randint(ticket.price, ticket.price + 1000)

    def dispense_change(self, ticket, on_pay_change_to_mobile_phone):
        if self._cash_accepted > ticket.price and \
                (not self.try_to_dispense(self._cash_accepted - ticket.price)):
            on_pay_change_to_mobile_phone()

    def try_to_dispense(self, change_amount):
        pass  # return False or True depending on successfulness
