using BlueBird.Data;
using BlueBird.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlueBird.Controllers
{
    public class UserFormController : Controller
    {
        private readonly UserFormContext _context;

        public UserFormController(UserFormContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userFormViewModel = new UserFormViewModel
            {
                SectorData = await GetSectorData()
            };

            return View(userFormViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserFormViewModel userFormViewModel)
        {
            if (ModelState.IsValid)
            {
                ModelState.Remove("UserFormFillingId");

                var sectors = await _context.SectorData.ToListAsync();
                var selectedSectors = sectors.Where(x => userFormViewModel.SectorValues.Any(y => y == x.Value));


                var existingUserForm = await _context.UserFormFilling.Where(x => x.Id == userFormViewModel.UserFormFillingId).FirstOrDefaultAsync();

                if (userFormViewModel.UserFormFillingId == Guid.Empty || existingUserForm == null)
                {
                    var userFormFilling = Init(selectedSectors, new UserFormFilling(), userFormViewModel);

                    _context.Add(userFormFilling);
                    await _context.SaveChangesAsync();

                    userFormViewModel.UserFormFillingId = userFormFilling.Id;
                }

                else
                {
                    var sectorsToDelete = await _context.Sector.Where(x => x.UserFormFilling.Id == userFormViewModel.UserFormFillingId).ToListAsync();
                    if (sectorsToDelete.Any())
                    {
                        _context.RemoveRange(sectorsToDelete);
                        await _context.SaveChangesAsync();
                    }

                    existingUserForm = Init(selectedSectors, existingUserForm, userFormViewModel);

                    _context.Update(existingUserForm);
                    await _context.SaveChangesAsync();
                }

                userFormViewModel.SectorData = GetSectorData(sectors);
            }
            else
                userFormViewModel.SectorData = await GetSectorData();

            return View(userFormViewModel);
        }

        private List<SectorData> GetSectorData(List<SectorData> sectorData)
        {
            var sectorDataFiltered = sectorData.Where(x => x.ParentId == null).OrderBy(x => x.Name).ToList();

            MakeOrder(sectorDataFiltered);

            return sectorDataFiltered;
        }

        private async Task<List<SectorData>> GetSectorData()
        {
            var sectorData = await _context.SectorData.ToListAsync();
            var sectorDataFiltered = sectorData.Where(x => x.ParentId == null).OrderBy(x => x.Name).ToList();

            MakeOrder(sectorDataFiltered);

            return sectorDataFiltered;
        }

        private void MakeOrder(ICollection<SectorData> data)
        {
            foreach (var element in data)
            {
                if (element.Children != null)
                {
                    element.Children = element.Children.OrderBy(x => x.Name).ToList();
                    MakeOrder(element.Children);
                }
            }
        }

        private UserFormFilling Init(IEnumerable<SectorData> sectorData, UserFormFilling userForm, UserFormViewModel userFormViewModel)
        {
            userForm.Name = userFormViewModel.Name;
            userForm.IsAgreedToTerms = userFormViewModel.IsAgreedToTerms;
            userForm.Sectors = new List<Sector>();

            foreach (var element in sectorData)
            {
                userForm.Sectors.Add(new Sector { Name = element.Name, Value = element.Value });
            }
            return userForm;
        }
    }
}