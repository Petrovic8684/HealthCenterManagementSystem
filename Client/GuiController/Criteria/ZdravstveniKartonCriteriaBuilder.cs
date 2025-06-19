using Common.Domain;
using Common.Communication;
using Client.GuiController.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using Client;

internal class ZdravstveniKartonCriteriaBuilder : CriteriaBuilderBase<ZdravstveniKarton>
{
    internal ZdravstveniKartonCriteriaBuilder WithDatumOtvaranjaAfter(DateTime datum)
    {
        if (datum != DateTime.Today)
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new ZdravstveniKarton { DatumOtvaranja = datum };
                var response = Communication.Instance.SendRequestGetList<ZdravstveniKarton, ZdravstveniKarton>(criterion, Operation.VratiListuZdravstveniKartonPoZdravstvenomKartonu);
                return response.Result as List<ZdravstveniKarton>;
            });
        }
        return this;
    }

    internal ZdravstveniKartonCriteriaBuilder WithImeLekara(string ime)
    {
        if (!string.IsNullOrWhiteSpace(ime))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Lekar { Ime = ime.Trim() };
                var response = Communication.Instance.SendRequestGetList<Lekar, ZdravstveniKarton>(criterion, Operation.VratiListuZdravstveniKartonPoLekaru);
                return response.Result as List<ZdravstveniKarton>;
            });
        }
        return this;
    }

    internal ZdravstveniKartonCriteriaBuilder WithImePacijenta(string ime)
    {
        if (!string.IsNullOrWhiteSpace(ime))
        {
            AddCriteriaFetcher(() =>
            {
                var criterion = new Pacijent { Ime = ime.Trim() };
                var response = Communication.Instance.SendRequestGetList<Pacijent, ZdravstveniKarton>(criterion, Operation.VratiListuZdravstveniKartonPoPacijentu);
                return response.Result as List<ZdravstveniKarton>;
            });
        }
        return this;
    }

    internal ZdravstveniKartonCriteriaBuilder WithDijagnoza(Dijagnoza dijagnoza)
    {
        if (dijagnoza != null && dijagnoza.Id != -1)
        {
            AddCriteriaFetcher(() =>
            {
                var response = Communication.Instance.SendRequestGetList<Dijagnoza, ZdravstveniKarton>(dijagnoza, Operation.VratiListuZdravstveniKartonPoDijagnozi);
                return response.Result as List<ZdravstveniKarton>;
            });
        }
        return this;
    }

    internal override List<ZdravstveniKarton> Build()
    {
        if (!HasCriteria)
            throw new Exception("Izaberite bar jedan kriterijum pretrage.");

        var resultSets = GetResults();
        return resultSets.Aggregate((prev, next) => prev.Intersect(next, new EntityIdComparer()).ToList());
    }

    protected override Operation GetAllOperation() => throw new NotImplementedException();
}