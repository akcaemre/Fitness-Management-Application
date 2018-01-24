import { TransactionModule } from './transactions.module';

describe('TransactionModule', () => {
    let TransactionModule: TransactionModule;

    beforeEach(() => {
        TransactionModule = new TransactionModule();
    });

    it('should create an instance', () => {
        expect(TransactionModule).toBeTruthy();
    });
});
