from abc import ABC, abstractmethod
from random import randint

from example import TicketDetails, PaymentDetails


class CanOperateWithCash(ABC):

    @abstractmethod
    def accept_cash(self):
        pass

    @abstractmethod
    def dispsense_change(self):
        pass


class CanPayViaCreditCard(ABC):

    @abstractmethod
    def charge_card(self, ticket: TicketDetails, payment: PaymentDetails):
        pass


class PaymentModel(ABC):
    def __init__(self, ticket: TicketDetails):
        self.ticket = ticket

    @abstractmethod
    def buy_ticket(self):
        pass


class BankGateway(CanPayViaCreditCard):

    def charge_card(self, ticket: TicketDetails, payment: PaymentDetails):
        pass


class OnlinePayment(PaymentModel):

    def __init__(self, ticket: TicketDetails, payment: PaymentDetails):
        super().__init__(ticket)
        self._payment = payment
        self._bank_gateway = BankGateway()

    def buy_ticket(self):
        self._bank_gateway.charge_card(self.ticket, self._payment)


class PosTerminalPayment(PaymentModel, CanOperateWithCash):

    def __init__(self, ticket: TicketDetails, on_pay_change_to_mobile_phone):
        super().__init__(ticket)
        self.on_pay_change_to_mobile_phone = on_pay_change_to_mobile_phone

    def dispsense_change(self):
        if self._cash_accepted > self.ticket.price and \
                (not self.try_to_dispense(self._cash_accepted - self.ticket.price)):
            self.on_pay_change_to_mobile_phone()

    def accept_cash(self):
        self._cash_accepted = randint(self.ticket.price, self.ticket.price + 1000)

    def buy_ticket(self):
        self.accept_cash()
        self.dispsense_change()

    def try_to_dispense(self, to_dispense):
        pass  # return False or True depending on successfulness
